Ако ще бъде пулван проекта , ако изберете да си използвате собственият connectionString , при миграциите за свързващите таблици (EventsAccounts,EventsProfiles , etc.), 'onDelete: ReferentialAction.Cascade' трябва да се смени на 'onDelete: ReferentialAction.NoAction' ръчно.

If the project is pulled ,if you choose to use your own connectionString ,  when creating migrations for connecting tables (EventsAccounts,EventsProfiles , etc.), 'onDelete: ReferentialAction.Cascade' needs to be changed to 'onDelete: ReferentialAction.NoAction' manually.
