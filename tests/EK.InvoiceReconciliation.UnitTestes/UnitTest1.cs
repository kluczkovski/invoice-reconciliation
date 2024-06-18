namespace EK.InvoiceReconciliation.UnitTestes;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var a = 10;
        var b = 20;

        //Act
        var c =  a + b;

        //Assert
        Assert.Equal(30, c);
    }
}
