const tblBlog = "blogs";
getBlogTable();
let blogId = null;
//createBlog();
//updateBlog("87796600-e5ce-4e0b-8416-3aaa30ecc041","Catoon","JameBook","Tom&Jerry");
//deleteBlog("87796600-e5ce-4e0b-8416-3aaa30ecc041");

function readBlog() {
    let lst = getBlogs();
    console.log(lst);
}
function createBlog(title, author, content) {
    let lst = getBlogs();
    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };
    lst.push(requestModel);  // add the data to array use push 

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Saving is Sucessful");
    clearControls();
}
function editBlog(id) {
    let lst = getBlogs();
    const items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.lenght);
    if (items.lenght == 0) {
        console.log("data not found");
        errorMessage("data not found");
        return;
    }

    let item = items[0];
    blogId=item.id;
    $('#txtTitle').val(item.title);
    $('#txtcontent').val(item.content);
    $('#txtauthor').val(item.author);
    $('#txtTitle').focus();

}
function updateBlog(id, title, author, content) {
     let lst = getBlogs();
    const items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.lenght);
    if (items.lenght == 0) {
        console.log("data not found");
        errorMessage("data not found");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Update is Done");
}
function deleteBlog(id) {
    let result = "are u sure u want to delete";
    if(!result) return;

    let lst = getBlogs();
    const items = lst.filter(x => x.id === id);
    if (items.lenght == 0) {
        console.log("data not found");
        errorMessage("data not found");
        return;
    }
    lst = lst.filter(x => x.id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Delete is Sucessful");
    getBlogTable();
}
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}
function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}
$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtauthor').val();
    const content = $('#txtcontent').val();

    if (blogId === null) {
        createBlog(title, author, content);
    }
    else {
        updateBlog(blogId, title, author, content);
        blogId = null;
    }
    getBlogTable();

})
function successMessage(message) {
    Swal.fire({
        title: "Success!",
        text: message,
        icon: "success"
        });
}
function errorMessage(message) {
    Swal.fire({
        title: "Error!",
        text: message,
        icon: "error"
    });
}
function clearControls() {
    $('#txtTitle').val('');
    $('#txtauthor').val('');
    $('#txtcontent').val('');
    $('#txtTitle').focus();
}
function getBlogTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmRow = `
        <tr>
            <td>
                <button type="button" class="btn btn-waring" onclick="editBlog('${item.id}')">Edit</button>
                <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.id}')">Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
        </tr>
        `;
        htmlRows += htmRow;
    });

    $('#tbody').html(htmlRows);
}