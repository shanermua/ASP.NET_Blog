namespace BlogSystem.Web.Hubs.ChatHelpersClasses
{
    using System.Collections.Generic;

    public class PublicChatRoom : AbstractChatRoom
    {
        private readonly Dictionary<string, Participant> participants =
            new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!this.participants.ContainsValue(participant))
            {
                this.participants[participant.Name] = participant;
            }

            participant.ChatRoom = this;
        }

        public override void Send(string from, string to, string message)
        {
            var participant = this.participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }
}