using ExamenP3.Repositories;
using Microsoft.Extensions.Logging;

namespace ExamenP3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
<<<<<<< HEAD
    		builder.Logging.AddDebug();
=======
            builder.Logging.AddDebug();
#endif
>>>>>>> penultima

#endif
            string dbPath = FileAccessHelper.GetLocalFilePath("chuck.db3");
            builder.Services.AddSingleton<PaisesRepositories>(s => ActivatorUtilities.CreateInstance<PaisesRepositories>(s, dbPath));
            return builder.Build();

        }
    }
}