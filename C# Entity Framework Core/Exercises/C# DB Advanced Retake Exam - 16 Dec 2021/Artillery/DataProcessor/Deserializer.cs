namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var countries = new List<Country>();

            var countriesDto = XmlConverter.Deserializer<CountriesXmlImportModel>(xmlString, "Countries");

            foreach (var currentCountry in countriesDto)
            {
                if (!IsValid(currentCountry))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country
                {
                    CountryName = currentCountry.CountryName,
                    ArmySize = currentCountry.ArmySize,
                };

                countries.Add(country);

                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var manufacturers = new List<Manufacturer>();

            var manufacturersDto = XmlConverter.Deserializer<ManufacturerXmlImportModel>(xmlString, "Manufacturers");

            foreach (var currentManufacturer in manufacturersDto)
            {
                if (!IsValid(currentManufacturer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var name = manufacturers.FirstOrDefault(m => m.ManufacturerName == currentManufacturer.ManufacturerName);

                if (name != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer
                {
                    ManufacturerName = currentManufacturer.ManufacturerName,
                    Founded = currentManufacturer.Founded,
                };

                manufacturers.Add(manufacturer);

                var founded = manufacturer.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                sb.AppendLine($"Successfully import manufacturer {manufacturer.ManufacturerName} founded in {founded[founded.Length - 2] + ", " + founded[founded.Length - 1]}.");
            }

            context.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var shells = new List<Shell>();

            var shellsDto = XmlConverter.Deserializer<ShellXmlImportModel>(xmlString, "Shells");

            foreach (var currentShell in shellsDto)
            {
                if (!IsValid(currentShell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell
                {
                    ShellWeight = currentShell.ShellWeight,
                    Caliber = currentShell.Caliber,
                };

                shells.Add(shell);

                sb.AppendLine(String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var guns = new List<Gun>();

            var gunsDto = JsonConvert.DeserializeObject<IEnumerable<GunJsonImportModel>>(jsonString);

            foreach (var currentGun in gunsDto)
            {
                if (!IsValid(currentGun))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
                {
                    GunWeight = currentGun.GunWeight,
                    ManufacturerId = currentGun.ManufacturerId,
                    BarrelLength = currentGun.BarrelLength,
                    NumberBuild = currentGun.NumberBuild,
                    Range = currentGun.Range,
                    GunType = Enum.Parse<GunType>(currentGun.GunType),
                    ShellId = currentGun.ShellId,
                    CountriesGuns = currentGun.Countries.Select(x => new CountryGun
                    {
                        CountryId = x.Id,
                    })
                    .ToList()
                };

                guns.Add(gun);

                sb.AppendLine(String.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            context.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
