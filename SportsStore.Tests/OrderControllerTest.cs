using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public class OrderControllerTest
    {
        [Fact]
        public void Cannot_Checkout_Empty_Cart()
        {
            //Arrange
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            Cart cart = new Cart();

            Order order = new Order();

            OrderController target = new OrderController(mock.Object, cart);

            //Act
            ViewResult result = target.Checkout(order) as ViewResult;

            //Assert
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);

            Assert.True(string.IsNullOrEmpty(result.ViewName));

            Assert.False(result.ViewData.ModelState.IsValid);
        }
    }
}
