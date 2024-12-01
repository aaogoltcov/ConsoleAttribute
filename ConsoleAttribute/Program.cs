namespace ConsoleAttribute;

class Program
{
    static T Create<T>()
    {
        T obj = Activator.CreateInstance<T>();

        if (obj == null)
        {
            throw new Exception("Failed to create instance");
        }

        Type type = obj.GetType();

        var members = type.GetMembers(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

        foreach (var member in members)
        {
            var attributes = member.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                if (attribute is CustomName customNameAttribute)
                {
                    Console.WriteLine(customNameAttribute.Name);
                }
            }
        }

        return obj;
    }

    static void Main(string[] args)
    {
        var testObj = Create<TestClass>();
    }
}