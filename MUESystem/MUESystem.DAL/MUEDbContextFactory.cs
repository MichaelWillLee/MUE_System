using System.Runtime.Remoting.Messaging;

namespace MUESystem.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// </summary>
    public class MUEDbContextFactory
    {
        public static MUEDbContext GetCurrentContext()
        {
            MUEDbContext mContext = CallContext.GetData("MUESystem") as MUEDbContext;
            if (mContext == null)
            {
                mContext = new MUEDbContext();
                CallContext.SetData("MUESystem", mContext);
            }
            return mContext;
        }
    }
}
