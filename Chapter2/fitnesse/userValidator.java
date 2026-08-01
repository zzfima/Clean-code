public class UserValidator {
    private Cryptographer cryptographer;

    public UserValidator(Cryptographer cryptographer) {
        this.cryptographer = cryptographer;
    }

    public boolean checkPassword(String userName, String password) {
        User user = UserGateway.findByName(userName);
        if (user != User.NULL) {
            String codedPhrase = user.getPhraseEncodedByPassword();
            String phrase = cryptographer.decrypt(codedPhrase, password);
            if ("Valid Password".equals(phrase)) {
                Session.initialize(); //side effect: initializes the session for the user
                return true;
            }
        }
        return false;
    }
}