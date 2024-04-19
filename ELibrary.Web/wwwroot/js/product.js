$(document).ready(() => loadDataTable());

let dataTable;

const loadDataTable = () => {
  dataTable = new DataTable("#myTable", {
    ajax: { url: "/Admin/Product/getAll" },
    columns: [
      { data: "title", width: "25%" },
      { data: "description", width: "30%" },
      { data: "author", width: "15%" },
      { data: "categoryName", width: "15%" },
      {
        data: "id",
        render: (data) => {
          return `<div class="w-75 btn-group" role="group">
            <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2">
            <i class="bi bi-pencil-square"></i>
            Edit
            </a>
            <a onClick=deleteFunc("/admin/product/delete?id=${data}") class="btn btn-danger mx-2">
            <i class="bi bi-trash-fill"></i>
            Delete
            </a>
          </div>`;
        },
        width: "15%",
      },
    ],
  });
};

const deleteFunc = (url) => {
  Swal.fire({
    title: "Are you sure?",
    text: "You won't be able to revert this!",
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    confirmButtonText: "Yes, delete it!",
  }).then((result) => {
    if (result.isConfirmed) {
      $.ajax({
        url: url,
        type: "Delete",
        success: (data) => {
          if (data.success) {
            createSuccessOrFailSwal(true, data.message);
            dataTable.ajax.reload();
            return;
          }
          createSuccessOrFailSwal(false, data.message);
        },
      });
    }
  });
};

const createSuccessOrFailSwal = (success, message) => {
  if (success) {
    return Swal.fire({
      title: "Deleted!",
      text: message,
      icon: "success",
    });
  }
  return Swal.fire({
    title: "Something Went Wrong!",
    text: message,
    icon: "error",
  });
};
