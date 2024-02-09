using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH02
{
    public interface IBreakfast
    {
        Task MakeBreakfastAsync(int eggs, int bacon);
    }

    public class Breakfast : IBreakfast
    {
        public async Task MakeBreakfastAsync(int eggs, int bacon)
        {
            Output("開始製作早餐 ...\n");
            Task coffeeTask = MakeCoffee();
            Task heatPanTask = HeatPan();
            Task toastBreadTask = ToastBread();
            await Task.WhenAll(coffeeTask, heatPanTask);
            await FryEggs(eggs);
            await FryBacon(bacon);
            await toastBreadTask;
            await ApplyButter();
            await ApplyJam();
            await PourJuice();
            Output("\n早餐已經準備好了");
            return;
        }
        void Output(string message)
        {
            Console.WriteLine($"{DateTime.Now}  {message}");
        }
        async Task MakeCoffee()
        {
            Output("[1] 製作咖啡中 ...");
            await Task.Delay(3000);
            Output("[1] 咖啡已經準備好了");
            return;
        }

        async Task HeatPan()
        {
            Output("[2] 煎鍋預熱中 ...");
            await Task.Delay(8000);
            Output("[2] 煎鍋已經預熱好了");
            return;
        }

        async Task FryEggs(int howMany)
        {
            Output("[3] 開始製作太陽蛋 ...");
            for (int egg = 1; egg <= howMany; egg++)
            {
                Output($"[3]   煎製{egg}顆太陽蛋中 ...");
                await Task.Delay(4000);
                Output($"[3]   煎製{egg}顆太陽蛋完成 ...");
            }
            Output("[3] 太陽蛋已經煎好了");
            return;
        }

        async Task FryBacon(int slices)
        {
            Output("[4] 開始製作香酥培根中 ...");
            for (int slice = 1; slice <= slices; slice++)
            {
                Output($"[4]   煎製{slice}片培根中 ...");
                await Task.Delay(4000);
                Output($"[4]   煎製{slice}片培根完成 ...");
            }
            Output("[4] 香酥培根已經煎好了");
            return;
        }
        async Task ToastBread()
        {
            Output("[5] 開始烤土司中 ...");
            await Task.Delay(3000);
            Output("[5] 烤土司已經烤好了");
            return;
        }

        async Task ApplyJam()
        {
            Output("[6] 開始塗抹果醬中 ...");
            await Task.Delay(2000);
            Output("[6] 果醬已經塗抹上土司了");
            return;
        }

        async Task ApplyButter()
        {
            Output("[7] 開始塗抹奶油中 ...");
            await Task.Delay(2000);
            Output("[7] 奶油已經塗抹上土司了");
            return;
        }

        async Task PourJuice()
        {
            Output("[8] 開始準備果汁中 ...");
            await Task.Delay(3000);
            Output("[8] 果汁已經準備好了");
            return;
        }
    }
}
