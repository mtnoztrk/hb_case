using hb_case.Models;

namespace hb_case
{
    public interface IOrder
    {
        void Execute(IRover rover);
    }
}
