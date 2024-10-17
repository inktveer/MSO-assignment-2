namespace Ass2 {
    public abstract class Command {
        public abstract void execute();
    }

    public class Repeat : Command {
        private Avatar    associatedPlayer;
        private Command[] commands;

        public override void execute() {
            foreach (var c in commands) {
                c.execute();
            }
        }
    }
    
    
    
}