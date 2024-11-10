using System;
using System.Configuration;

public class ConfigEncryptor
{
    public static void EncryptConnectionString()
    {
        // Obtiene la configuración de la aplicación
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        // Obtiene la sección connectionStrings
        ConfigurationSection section = config.GetSection("connectionStrings");

        if (section != null && !section.SectionInformation.IsProtected)
        {
            // Protege la sección con el proveedor de DataProtection
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
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        ConfigurationSection section = config.GetSection("connectionStrings");

        if (section != null && section.SectionInformation.IsProtected)
        {
            section.SectionInformation.UnprotectSection();
            section.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);

            Console.WriteLine("La sección connectionStrings ha sido desencriptada.");
        }
    }
}
