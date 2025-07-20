select
    "Name",
    "Description"
from "CodeCraft"."Products"
WHERE "Id" = @Id
    AND "IsDeleted" = false;