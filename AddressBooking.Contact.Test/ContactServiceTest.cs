using AddressBooking.Api.Controllers;
using AddressBooking.Application;
using AddressBooking.Core;
using AddressBooking.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using Xunit;

namespace AddressBooking.ContactxUnit.Test
{
    public class ContactServiceTest
    {
        private Mock<IContactRepository> _mockContactRepository = new Mock<IContactRepository>();
        private Mock<IMapper> _mapper = new Mock<IMapper>();
        private IContactService _contactService;

        [Fact]
        public async void DelectContact_InvaildId()
        {
            // Arrange
            int id = 0;
            _contactService = new ContactService(_mockContactRepository.Object, _mapper.Object);
            var model = new Contact()
            {
                Id = id
            };

            // Act
            var results = await _contactService.DeleteContactAsync(id,CancellationToken.None);

            // Assert
            Xunit.Assert.False(results, "Invaild Id.");
            _mockContactRepository.Verify(c => c.FindByIdAsync(id, CancellationToken.None),Times.Never(),"invaild id.");
            _mockContactRepository.Verify(c => c.UpdateAsync(model, CancellationToken.None), Times.Never(), "invaild id.");
        }

        [Fact]
        public async void DelectContact_VaildIdNotFound()
        {
            // Arrange 
            int id = 1;
            _contactService = new ContactService(_mockContactRepository.Object, _mapper.Object);
            var model = new Contact()
            {
                Id = id
            };

            // Act
            var results = await _contactService.DeleteContactAsync(id, CancellationToken.None);

            // Assert
            Xunit.Assert.False(results, "Contact false.");
            _mockContactRepository.Verify(c => c.FindByIdAsync(id, CancellationToken.None),Times.Once(), "Not found");
            _mockContactRepository.Verify(c => c.UpdateAsync(model, CancellationToken.None), Times.Never(), "Not found.");

        }

        [Fact]
        public async void DelectContact_ValidIdFound()
        {
            // Arrange 
            var model = new Contact()
            {
                Id = 1
            };
            _mockContactRepository.Setup(c => c.FindByIdAsync(model.Id, CancellationToken.None)).ReturnsAsync(model);
            _contactService = new ContactService(_mockContactRepository.Object, _mapper.Object);


            // Act

            var results = await _contactService.DeleteContactAsync(model.Id, CancellationToken.None);

            // Assert
            Xunit.Assert.True(results, "Contact false.");
            _mockContactRepository.Verify(c => c.FindByIdAsync(model.Id, CancellationToken.None), Times.Once(), "Not found");
            _mockContactRepository.Verify(c => c.UpdateAsync(model, CancellationToken.None), Times.Once(), "Not found.");
        }

        [Fact]
        public async void GetContact()
        {
            // ARRANGE
            var model = new Contact
            {
                Id = 1,
                ContactName = "Test Name",
                ContactSurname = "Test Surname",
                ContactNumber = "0736541258",
                Age = 5,
                DateOfBirth = DateTime.Now,
                IsDeleted = false
            };

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _mockContactRepository.Setup(c => c.FindByIdAsync(model.Id, CancellationToken.None)).ReturnsAsync(model);
 
            _contactService = new ContactService(_mockContactRepository.Object, mapper);

            // ACT
            var results = await _contactService.GetContactAsync(model.Id, CancellationToken.None);

            // ASSERT
            Xunit.Assert.Equal(model.Id, results.Id);
            _mockContactRepository.Verify(c => c.FindByIdAsync(1, CancellationToken.None), Times.Once(), "Found");

        }

        [Fact]
        public async void GetContacts_Found()
        {
            // Arrange
            var contacts = LoadActiveContacts();
            _mockContactRepository.Setup(c => c.FindAllAsync(CancellationToken.None)).ReturnsAsync(contacts);
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            _contactService = new ContactService(_mockContactRepository.Object, mapper);

            // Act
            var results = await _contactService.GetContactsAsync(CancellationToken.None);

            // Assert
            Xunit.Assert.NotEmpty(results);
            _mockContactRepository.Verify(c => c.FindAllAsync(CancellationToken.None), Times.Once(), "Found");
        }

        [Fact]
        public async void GetContacts_NotFound()
        {
            // Arrange
            var contacts = new List<Contact>();
            _mockContactRepository.Setup(c => c.FindAllAsync(CancellationToken.None)).ReturnsAsync(contacts);
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            _contactService = new ContactService(_mockContactRepository.Object, mapper);

            // Act
            var results = await _contactService.GetContactsAsync(CancellationToken.None);

            // Assert
            Xunit.Assert.Empty(results);
            _mockContactRepository.Verify(c => c.FindAllAsync(CancellationToken.None), Times.Once(), "Found");
        }

        [Fact]
        public async void InsertContact_ValidModel()
        {
            // Arrange 
            var model = new Contact()
            {
                Id = 1,
                ContactName = "Test Name",
                ContactSurname = "Test Surname",
                ContactNumber = "0736541258",
                Age = 5,
                DateOfBirth = DateTime.Now,
                IsDeleted = false
            };
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            _mockContactRepository.Setup(c => c.InsertAsync(model, CancellationToken.None)).ReturnsAsync(model);
            _contactService = new ContactService(_mockContactRepository.Object, mapper);


            // Act
            var entity = mapper.Map<ContactDto>(model);
            var results = await _contactService.InsertContactAsync(entity, CancellationToken.None);

            // Assert
            Xunit.Assert.True(results, "Contact True");
            _mockContactRepository.Verify(c => c.InsertAsync(model, CancellationToken.None), Times.Once(), "Contact Inserted");
        }

        [Fact]
        public async void InsertContact_InvaildModel()
        {
            // Arrange 
            Contact model = null;
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            _mockContactRepository.Setup(c => c.InsertAsync(model, CancellationToken.None)).ReturnsAsync(model);
            _contactService = new ContactService(_mockContactRepository.Object, mapper);


            // Act
            var entity = mapper.Map<ContactDto>(model);
            var results = await _contactService.InsertContactAsync(entity, CancellationToken.None);

            // Assert
            Xunit.Assert.False(results, "Invaild model");
            _mockContactRepository.Verify(c => c.InsertAsync(model, CancellationToken.None), Times.Never(), "Invaild model");
        }

        #region Load Contacts
        public List<Contact> LoadActiveContacts()
        {
            List<Contact> contacts = new List<Contact>()
            {
                new Contact
                {
                    Id = 1,
                    ContactName = "Test Name",
                    ContactSurname = "Test Surname",
                    ContactNumber = "0736541258",
                    Age = 5,
                    DateOfBirth = DateTime.Now,
                    IsDeleted = false
                },
                new Contact
                {
                    Id = 2,
                    ContactName = "Test Name",
                    ContactSurname = "Test Surname",
                    ContactNumber = "0736541258",
                    Age = 5,
                    DateOfBirth = DateTime.Now,
                    IsDeleted = false
                },
                new Contact
                {
                    Id = 3,
                    ContactName = "Test Name",
                    ContactSurname = "Test Surname",
                    ContactNumber = "0736541258",
                    Age = 5,
                    DateOfBirth = DateTime.Now,
                    IsDeleted = false
                },
                new Contact
                {
                    Id = 4,
                    ContactName = "Test Name",
                    ContactSurname = "Test Surname",
                    ContactNumber = "0736541258",
                    Age = 5,
                    DateOfBirth = DateTime.Now,
                    IsDeleted = false
                }
            };

            return contacts;
        }
        #endregion  
    }
}