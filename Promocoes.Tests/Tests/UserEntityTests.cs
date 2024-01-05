using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Domain.Entities;
using Promocoes.Domain.Validations;


namespace Promocoes.Tests.Tests
{
    [TestClass]
    public class UserEntityTests
    {
        public UserEntity _user;
        public UserValidations _validations;

        public UserEntityTests()
        {
            var date = DateTime.Now;
            _user = new UserEntity("Ramon", "ramonramos.silva19@gmail.com", "ramonramos9137", "", date);
            _validations = new UserValidations(_user);
        }

        [TestMethod]
        public void GuidIsValid()
        {
            Assert.IsTrue(_validations.GuidIsValid().IsValid());
        }

        [TestMethod]
        public void NameIsValid()
        {
            Assert.IsTrue(_validations.NameIsValid().IsValid());
        }
        
        [TestMethod]
        public void EmailIsValid()
        {
            Assert.IsTrue(_validations.EmailIsValid().IsValid());
        }

        [TestMethod]
        public void NameLength()
        {
            Assert.IsTrue(_validations.NameLength().IsValid());
        }

        [TestMethod]
        public void PasswordLength()
        {
            Assert.IsTrue(_validations.PasswordLength().IsValid());
        }
    }
}