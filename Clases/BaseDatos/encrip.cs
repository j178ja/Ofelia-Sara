using System;
using System.ComponentModel;
using System.Configuration;
public class ConfigEncryptor
{
    public static void EncryptConnectionString()
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            Console.WriteLine("No se ejecutará en modo diseño.");
            return;
        }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        ConfigurationSection section = config.GetSection("connectionStrings");

        if (section != null && !section.SectionInformation.IsProtected)
        {
            section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            section.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);

            Console.WriteLine("La sección connectionStrings ha sido encriptada.");
        }
        else
        {
            Console.WriteLine("La sección connectionStrings ya está encriptada o no se encontró.");
        }
    }

    public static void DecryptConnectionString()
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            Console.WriteLine("No se ejecutará en modo diseño.");
            return;
        }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        ConfigurationSection section = config.GetSection("connectionStrings");

        if (section != null && section.SectionInformation.IsProtected)
        {
            section.SectionInformation.UnprotectSection();
            section.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);

            Console.WriteLine("La sección connectionStrings ha sido desencriptada.");
        }
        else
        {
            Console.WriteLine("La sección connectionStrings ya está desencriptada o no se encontró.");
        }
    }
}
