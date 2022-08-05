
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .ToArray()
                .Where(x => x.ShellWeight > shellWeight)
                .Select(x => new
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns.Where(x => x.GunType.ToString() == "AntiAircraftGun").Select(g => new
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range",
                    })
                    .OrderByDescending(x => x.GunWeight)
                })
                .OrderBy(x => x.ShellWeight)
                .ToList();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(x => x.BarrelLength)
                .Select(g => new GunXmlExportModel
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight.ToString(),
                    BarrelLength = g.BarrelLength.ToString(),
                    Range = g.Range.ToString(),
                    Countries = g.CountriesGuns
                    .Where(x => x.Country.ArmySize > 4500000)
                    .OrderBy(x => x.Country.ArmySize).Select(cg => new CountryXmlExportModel
                    {
                        Country = cg.Country.CountryName,
                        ArmySize = cg.Country.ArmySize.ToString(),
                    })
                    .ToArray()
                })
                .ToList();

            return XmlConverter.Serialize(guns, "Guns");
        }
    }
}
