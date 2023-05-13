namespace GPTEngine.Roles.Types
{
    internal class BiasedIdiot : RoleBehaviour
    {
        public override string Content => "I really don't like the Democrats, they are rude and think I am dumb. I strongly hold this belief and I can get quite inflamatory if you argue with me about it, ok!";

        public override ContentType ContentType => ContentType.ABiasedIdiot;
    }
}
