public class deleter {
    void deleteOld(Page page) {
        if (deletePage(page) == E_OK) {
            if (registry.deleteReference(page.name) == E_OK) {
                if (configKeys.deleteKey(page.name.makeKey()) == E_OK) {
                    logger.log("page deleted");
                } else {
                    logger.log("configKey not deleted");
                }
            } else {
                logger.log("deleteReference from registry failed");
            }
        } else {
            logger.log("delete failed");
            return E_ERROR;
        }
    }

    // refactoring: the above code has nested if statements that can be flattened
    // for better readability.
    void deleteRfct(Page page) {
        try {
            deletePage(page);
            registry.deleteReference(page.name);
            configKeys.deleteKey(page.name.makeKey());
        } catch (Exception e) {
            logger.log("Exception occurred: " + e.getMessage());
        }
    }

    // refactoring: the above code has nested if statements that can be flattened
    // for better readability.
    void deleteRfctEx(Page page) {
        try {
            deleteAllPagesAndReferences(page);
        } catch (Exception e) {
            logError(e);
        }
    }

    void deleteAllPagesAndReferences(Page page) {
        deletePage(page);
        registry.deleteReference(page.name);
        configKeys.deleteKey(page.name.makeKey());
    }

    void logError(Exception e) {
        logger.log("Exception occurred: " + e.getMessage());
    }
}