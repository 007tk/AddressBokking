using AddressBooking.Application;
using AddressBooking.Infrastructure.Repository;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace AddressBooking.Contact.UTest
{
    public class UnitTest1
    {
        private readonly Mock<ContactRepository> _contactRepositoryMock = new Mock<ContactRepository>();
        private IContactService _contactServiceMock;
        private IMapper _mapperMock;

        [TestInitialize]
        public void Setup()
        {
            _contactServiceMock = new ContactService(_contactRepositoryMock.Object, _mapperMock);
        }

        [TestCleanup]
        public void Teardown()
        {
            _contactServiceMock = null;
        }

        [TestMethod]
        public void GEtByKey_InvalidKey_ReturnNUll()
        {

        }
    }
}