using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using Newtonsoft.Json;

namespace the_Cryptocurrencies_bot_Movs
{
    public class API
    {
        static async Task Main(string[] args)
        {
            Mensaje m = new Mensaje();
            await m.CheckTHETAAsync();
            await m.CheckTRXAsync();
            await m.CheckUMAAsync();
            await m.CheckUNIAsync();
            await m.CheckVELOAsync();
            await m.CheckVETAsync();
            await m.CheckVRAAsync();
            await m.CheckWAVESAsync();
            await m.CheckXEMAsync();
            await m.CheckXLMAsync();
            await m.CheckXMRAsync();
            await m.CheckXPRTAsync();
            await m.CheckXRPAsync();
            await m.CheckXTZAsync();
        }
    }
}