namespace MainApp
{
    using System;

    public class South : DirectionState
    {

        public South() : base("S")
        {
        }

        protected internal override void Left(IRower rower)
        {
            rower.ChangeState(new East());
        }

        protected internal override void Right(IRower rower)
        {
            rower.ChangeState(new West());
        }

        protected internal override void Move(IRower rower, Strategy strategy)
        {
            int newY = rower.Y - strategy.Step;

            if (strategy.IsOutOfMap(newY, strategy.Plateau.Y) || strategy.IsCollisionCase(rower))
            {
                this.ErrorMessage(rower);
            }
            else
            {
                rower.Y = newY;
            }
        }
    }
}