createBlog();

function readBlog()
{
    localStorage.getItem();
}
function createBlog()
{
    const requestModel=
    {
        title: "test title",
        author: "test author",
        content: "test content"
    };
    const jsonblog=JSON.stringify(requestModel);
    localStorage.setItem("blogs", jsonblog);
}