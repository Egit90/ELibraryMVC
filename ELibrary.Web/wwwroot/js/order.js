$(document).ready(() => loadDataTable());

let dataTable;

const loadDataTable = () => {
  dataTable = new DataTable("#myTable", {
    ajax: { url: "/Admin/order/getAll" },
    columns: [
      { data: "id", width: "25%" },
      { data: "name", width: "30%" },
      { data: "email", width: "30%" },
      { data: "phoneNumber", width: "15%" },
      { data: "status", width: "15%" },
      { data: "total", width: "15%" },
      {
        data: "id",
        render: (data) => {
          return `<div class="w-75 btn-group" role="group">
            <a href="/admin/order/GetAll" class="btn btn-primary mx-2">
            <i class="bi bi-pencil-square"></i>
            Edit
            </a>
          </div>`;
        },
        width: "15%",
      },
    ],
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
