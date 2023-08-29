using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocoes.Application.Input.Commands.PromotionsContext;
using Promocoes.Application.Input.Receivers.Interfaces;

namespace Promocoes.Application.Input.Receivers.PromotionsReceiver
{
    public class Insert : IReceiver<PromotionsCommand, State>
    {
        public State Action(PromotionsCommand command)
        {
            throw new NotImplementedException();
        }
    }
}