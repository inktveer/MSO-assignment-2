namespace Ass2 {
    public abstract class Command {
        public abstract void execute();
    }

    public class Repeat : Command {
        private Avatar    associatedPlayer;

        public Command[] children {
            get;
        }

        public override void execute() {
            foreach (var c in children) {
                c.execute();
            }
        }
    }
    
    
    
}