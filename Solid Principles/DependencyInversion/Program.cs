using DependencyInversion;

DatabaseRecordKeeper DB_RecordKeeper = new DatabaseRecordKeeper(new PostgreSQL());
string errorCode = "505";
DB_RecordKeeper.Save(errorCode);

DB_RecordKeeper.Database = new MySQL();
DB_RecordKeeper.Save(errorCode);