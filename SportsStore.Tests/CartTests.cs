using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            //Arrange

            Product p1 = new Product() {ProductId = 1, Name = "P1"};
            Product p2 = new Product() {ProductId = 2, Name = "P2"};

            Cart target = new Cart();

            //Act

            target.AddItem(p1,1);
            target.AddItem(p2,2);
            Cart.CartLine[] results = target.Lines.ToArray();

            //Assert
            Assert.Equal(2,results.Length);
            Assert.Equal(p1,results[0].Product);
            Assert.Equal(p2,results[1].Product);
        }
    }
}
