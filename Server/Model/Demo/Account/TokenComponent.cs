using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
<<<<<<< HEAD
    [ChildType(typeof(Session))]
    public class TokenComponent: Entity, IAwake
    {
        public readonly Dictionary<long, string> TokenDictionary = new Dictionary<long, string>();
=======
    public class TokenComponent: Entity, IAwake
    {
        public Dictionary<long, string> TokenDictionary = new Dictionary<long, string>();
>>>>>>> main
    }
}