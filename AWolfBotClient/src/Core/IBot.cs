namespace AWolfBot.Core;

internal interface IBot : IHaveHandlers {
	public Task ConnectControllers();

}
