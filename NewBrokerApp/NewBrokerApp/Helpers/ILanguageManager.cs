using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewBrokerApp.Helpers
{
    public interface ILanguageManager
    {
        Task ChangeLanguage(AppLanguage lang);
    }
    public enum AppLanguage
    {
        English = 0,
        Arabic = 1
    }
}
