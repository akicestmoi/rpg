public interface IBackCommunicator {
    
    /* Get not used in local Front-Back construction, but should be used whenever the communication method changes (HTTP for ex) */
    public void Get();
    public void Post();
}