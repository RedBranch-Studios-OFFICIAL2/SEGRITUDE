namespace Segritude.Interaction
{
	public interface IInteractable
	{
		void StartInteraction(InteractionType type);

		void EndInteraction(InteractionType type);

		bool ValidateInteraction(InteractionType type);
	}
}