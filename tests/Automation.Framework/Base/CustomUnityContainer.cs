using Unity;

namespace Automation.Framework.Base;

public static class CustomUnityContainer
{
    private static readonly IUnityContainer UnityContainer;

    static CustomUnityContainer()
    {
        UnityContainer = new UnityContainer();
    }

    /// <summary>
    /// Retrieves unity containers registered 
    /// </summary>
    /// <returns>A unity container</returns>
    public static IUnityContainer GetContainer()
    {
        return UnityContainer;
    }
}
