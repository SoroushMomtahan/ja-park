using System.ComponentModel;
using System.Reflection;
using JaPark.Shared.Domain.Errors;
using JaPark.Shared.Domain.Results;

namespace JaPark.Shared.Domain;

[TypeConverter(typeof(PrefixedGuidConverter))] // این همچنان مفید است
public abstract record PrefixedGuidV3
{
    public string Value { get; }

    // سازنده اصلی که اعتبارسنجی را انجام می‌دهد
    protected PrefixedGuidV3(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        string expectedPrefix = GetPrefixFromAttribute(GetType());
        if (!value.StartsWith($"{expectedPrefix}-", StringComparison.Ordinal))
        {
            throw new FormatException($"Invalid prefix. Expected '{expectedPrefix}-'.");
        }

        string guidPart = value.Substring(expectedPrefix.Length + 1);
        if (!Guid.TryParse(guidPart, out _))
        {
            throw new FormatException("The value does not contain a valid GUID.");
        }

        Value = value;
    }

    // متد استاتیک برای ایجاد یک شناسه جدید
    public static T New<T>() where T : PrefixedGuidV3
    {
        string prefix = GetPrefixFromAttribute(typeof(T));
        string newGuidString = $"{prefix}-{Guid.CreateVersion7()}";
        // با استفاده از Activator یک نمونه از نوع مشتق‌شده می‌سازیم
        return (T)Activator.CreateInstance(typeof(T), newGuidString)!;
    }

    // متد استاتیک برای تجزیه (Parse) یک رشته و تبدیل آن به شناسه
    // این متد حالا فقط سازنده را فراخوانی می‌کند
    public static Result<T> From<T>(string input) where T : PrefixedGuidV3
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return Result<T>.ValidationFailure(new Error(
                code: "code.InvalidId",
                description: "شناسه نمی تواند خالی باشد",
                type:ErrorType.Validation));
        }
        string expectedPrefix = GetPrefixFromAttribute(typeof(T));
        if (!input.StartsWith($"{expectedPrefix}-", StringComparison.Ordinal))
        {
            return Result<T>.ValidationFailure(new Error(
                code: "code.InvalidIdFormat",
                description: $"پیشوند وارد شده اشتباه هست - انتظار می رود پیشوند با {expectedPrefix}- شروع شود.",
                type:ErrorType.Validation));
        }
        string guidPart = input.Substring(expectedPrefix.Length + 1);
        if (!Guid.TryParse(guidPart, out _))
        {
            return Result<T>.ValidationFailure(new Error(
                code: "code.InvalidGuid",
                description: "شناسه GUID معتبر نمی باشد",
                type:ErrorType.Validation));
        }
        // اعتبارسنجی در سازنده انجام می‌شود
        return (T)Activator.CreateInstance(typeof(T), input)!;
    }

    // بازنویسی متد ToString بسیار ساده می‌شود
    public override string ToString() => Value;

    // متد کمکی برای استخراج پیشوند از Attribute
    private static string GetPrefixFromAttribute(Type type)
    {
        PrefixAttribute? attribute = type.GetCustomAttribute<PrefixAttribute>();
        if (attribute is null)
        {
            throw new InvalidOperationException($"The type '{type.Name}' must have a [Prefix] attribute.");
        }
        return attribute.Prefix;
    }
    
    // برای اینکه بتوانیم به راحتی از رشته به این نوع تبدیل کنیم (implicit conversion)

    public static string ToString(PrefixedGuidV3 id) => id.Value;
}
public class PrefixedGuidConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object value)
    {
        if (value is string stringValue && context?.PropertyDescriptor != null)
        {
            Type targetType = context.PropertyDescriptor.PropertyType;
            MethodInfo? parseMethod = targetType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, [typeof(string)]);
            if (parseMethod != null)
            {
                // فراخوانی متد استاتیک Parse<T>
                return parseMethod.MakeGenericMethod(targetType).Invoke(null, [stringValue]);
            }
        }
        return base.ConvertFrom(context, culture, value);
    }
}


