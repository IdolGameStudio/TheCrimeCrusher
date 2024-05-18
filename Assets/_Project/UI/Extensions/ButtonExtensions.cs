using UnityEngine.UI;

namespace _Project.UI.Extensions
{
    public static class ButtonExtensions
    {
        public static ButtonAwaiter GetAwaiter(this Button button) => 
            new ButtonAwaiter(button);
    }
}