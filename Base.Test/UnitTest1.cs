using Base.App;
using System.Reflection;
using System.Security.Principal;

namespace Base.Test
{
    public class ClassTests
    {
        [Fact]
        public void AccountClassStructureTest()
        {
            Type accountType = typeof(Account);
            PropertyInfo idProperty = accountType.GetProperty("id")!;
            PropertyInfo accountTypeProperty = accountType.GetProperty("accountType")!;
            PropertyInfo balanceProperty = accountType.GetProperty("balance")!;

            Assert.NotNull(idProperty);
            Assert.NotNull(accountTypeProperty);
            Assert.NotNull(balanceProperty);

            Assert.Equal(typeof(int), idProperty.PropertyType);
            Assert.Equal(typeof(string), accountTypeProperty.PropertyType);
            Assert.Equal(typeof(decimal), balanceProperty.PropertyType);
        }

        [Fact]
        public void EmptyConstructorTest()
        {
            Type accountType = typeof(Account);
            ConstructorInfo emptyConstructor = accountType.GetConstructor(Type.EmptyTypes)!;

            Assert.NotNull(emptyConstructor);
        }

        [Fact]
        public void ParameterizedConstructorTest()
        {
            Type accountType = typeof(Account);
            ConstructorInfo parameterizedConstructor = accountType.GetConstructor(new[] { typeof(int), typeof(string), typeof(decimal) })!;

            Assert.NotNull(parameterizedConstructor);
        }
    }

    public class AccountTests
    {
        [Fact]
        public void WithdrawTest()
        {
            Type accountType = typeof(Account);
            ConstructorInfo parameterizedConstructor = accountType.GetConstructor(new[] { typeof(int), typeof(string), typeof(decimal) })!;
            if (parameterizedConstructor == null)
            {
                Account account = (Account)Activator.CreateInstance(accountType, new object[] { 1, "Savings", 1000 })!;

                // using reflection to test if Withdraw method exists
                MethodInfo withdrawMethod = accountType.GetMethod("Withdraw")!;
                if (withdrawMethod != null)
                {
                    withdrawMethod.Invoke(account, new object[] { 500 });
                    PropertyInfo balanceProperty = accountType.GetProperty("balance")!;
                    decimal balance = (decimal)balanceProperty.GetValue(account)!;
                    Assert.Equal(500, balance);
                }
            }

        }
    }
}