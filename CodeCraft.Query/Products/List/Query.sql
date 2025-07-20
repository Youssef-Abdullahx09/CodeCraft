select
    "Name",
    "Description",
    COUNT(*) OVER () AS Total
from "CodeCraft"."Products"
WHERE
    (CAST(@Name AS TEXT) IS NULL
        OR LOWER("Name") ILIKE LOWER(CAST(@Name AS TEXT)) || '%')
    AND "IsDeleted" = false
ORDER BY (CASE WHEN @OrderBy = 'Name' AND @SortDirection = 'ASC' THEN "Name" END),
         (CASE WHEN @OrderBy = 'Name' AND @SortDirection = 'DESC' THEN "Name" END) DESC
OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;