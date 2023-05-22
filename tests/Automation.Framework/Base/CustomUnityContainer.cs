using Unity;

namespace Automation.Framework.Base;

public static class CustomUnityContainer
{
    private static IUnityContainer _unityContainer;

    static CustomUnityContainer()
    {
        _unityContainer = new UnityContainer();
    }

    /// <summary>
    /// Retrives unity containers registered 
    /// </summary>
    /// <returns>A unity container</returns>
    public static IUnityContainer GetContainer()
    {
        return _unityContainer;
    }
}
