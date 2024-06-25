using Base.App;
using System.Reflection;

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
    }

    public class AccountTests
    {
        [Fact]
        public void WithdrawTest()
        {
            Account account = new Account(1, "Savings", 1000);
            account.Withdraw(500);
            Assert.Equal(500, account.Balance);
        }

        [Fact]
        public void GetDetailsTest()
        {
            Account account = new Account(1, "Savings", 1000);
            string expected = "Account ID: 1\nAccount Type: Savings\nBalance: 1000";
            Assert.Equal(expected, account.GetDetails());
        }
    }
}