using System;

namespace StateExample
{
    class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //create a new lamp context
            var context = new LampContext(new OffState());

            //using context with different states
            context.PushPowerButton();
            context.PushPowerButton();
        }
    }

    /// <summary>
    /// A Lamp Context class
    /// </summary>
    class LampContext
    {
        private LampState _lampState;

        public LampContext(LampState state)
        {
            SetState(state);
        }

        public void SetState(LampState state)
        {
            this._lampState = state;
            this._lampState.SetContext(this);
        }

        /// <summary>
        /// Lamp interface method
        /// </summary>
        public void PushPowerButton()
        {
            this._lampState.PushPowerButton();
        }
    }

    abstract class LampState
    {
        protected LampContext _lampContext;

        public void SetContext(LampContext context)
        {
            this._lampContext = context;
        }

        /// <summary>
        /// PushPowerButton abstract method
        /// </summary>
        public abstract void PushPowerButton();
    }

    class OffState : LampState
    {
        /// <summary>
        /// Concrete power button method for OffState
        /// </summary>
        public override void PushPowerButton()
        {
            Console.WriteLine("Turning ON");
            _lampContext.SetState(new OnState());
        }
    }

    class OnState : LampState
    {
        /// <summary>
        /// Concrete power button method for OnState
        /// </summary>
        public override void PushPowerButton()
        {
            Console.WriteLine("Turning OFF");
            _lampContext.SetState(new OffState());
        }
    }
}
