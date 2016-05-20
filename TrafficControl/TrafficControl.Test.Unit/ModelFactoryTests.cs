using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TrafficControl.BLL;
using TrafficControl.BLL.Cases;
using TrafficControl.BLL.CreateCase;
using TrafficControl.BLL.CreateUser;
using TrafficControl.BLL.Home;
using TrafficControl.BLL.LogIn;
using TrafficControl.BLL.Map;
using TrafficControl.BLL.Settings;

namespace TrafficControl.Test.Unit
{
    [TestFixture]
    public class ModelFactoryTests
    {
        [Test]
        public void CreateLogInModel_returnsCorrectSpecificType()
        {
            Assert.IsInstanceOf(typeof(LogInModel), ModelFactory.Instance.CreateLogInModel());
        }

        [Test]
        public void CreateHomeModel_returnsCorrectSpecificType()
        {
            Assert.IsInstanceOf(typeof(HomeModel), ModelFactory.Instance.CreateHomeModel());
        }

        [Test]
        public void CreateSettingsModel_returnsCorrectSpecificType()
        {
            Assert.IsInstanceOf(typeof(SettingsModel), ModelFactory.Instance.CreateSettingsModel());
        }

        [Test]
        public void CreateCreateUserModel_returnsCorrectSpecificType()
        {
            Assert.IsInstanceOf(typeof(CreateUserModel), ModelFactory.Instance.CreateCreateUserModel());
        }

        [Test]
        public void CreateUserPreference_returnsCorrectSpecificType()
        {
            Assert.IsInstanceOf(typeof(UserPreference), ModelFactory.Instance.CreateUserPreference());
        }

        [Test]
        public void CreateChangePasswordModel_returnsCorrectSpecificType()
        {
            Assert.IsInstanceOf(typeof(ChangePasswordModel), ModelFactory.Instance.CreateChangePasswordModel());
        }

        [Test]
        public void CreateCreateCaseModel_returnsCorrectSpecificType()
        {
            Assert.IsInstanceOf(typeof(CreateCaseModel), ModelFactory.Instance.CreateCreateCaseModel());
        }

        [Test]
        public void CreateMapModel_returnsCorrectSpecificType()
        {
            Assert.IsInstanceOf(typeof(MapModel), ModelFactory.Instance.CreateMapModel());
        }

        [Test]
        public void CreateCaseModel_returnsCorrectSpecificType()
        {
            Assert.IsInstanceOf(typeof(CaseModel), ModelFactory.Instance.CreateCaseModel());
        }
    }
}