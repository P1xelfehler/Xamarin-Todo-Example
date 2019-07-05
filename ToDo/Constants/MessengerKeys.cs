using System;
namespace ToDo.Constants
{
    public static class MessengerKeys
    {
        // A Todo-Item was added to the data storage.
        public const string ItemAdded = "ItemAdded";

        // A Todo-Item was changed.
        public const string ItemChanged = "ItemChanged";

        // A Todo-Item was deleted.
        public const string ItemDeleted = "ItemDeleted";
    }
}
