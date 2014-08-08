-- Ajout des deux nouvelles colonnes
ALTER TABLE [InfosClubs] ADD [Ville] nvarchar(4000) NULL;
GO
ALTER TABLE [InfosClubs] ADD [CodePostal] nvarchar(4000) NULL;
GO
-- Suppression de la colonne Ville_ID ainsi que ses contraintes (Index+FK)
ALTER TABLE [InfosClubs] DROP CONSTRAINT [FK_dbo.InfosClubs_dbo.Villes_Ville_ID];
GO
DROP INDEX [InfosClubs].[IX_Ville_ID];
GO
ALTER TABLE [InfosClubs] DROP COLUMN [Ville_ID];
GO