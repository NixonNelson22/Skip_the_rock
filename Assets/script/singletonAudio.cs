public sealed class singleton
{
    private static singleton instance = null;
    private singleton(){}
    
    public static singleton Instance{
        get{
            if(instance==null){
                instance = new singleton();
            }
            return instance;
        }
    }

}
