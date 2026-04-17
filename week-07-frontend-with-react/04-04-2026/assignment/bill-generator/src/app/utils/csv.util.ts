export function exportCSV(data: any[]) {
  const rows = data.map(d =>
    `${d.name},${d.qty},${d.price}`
  );

  const csv = "Name,Qty,Price\n" + rows.join("\n");

  const blob = new Blob([csv], { type: 'text/csv' });
  const link = document.createElement('a');

  link.href = URL.createObjectURL(blob);
  link.download = "bill.csv";
  link.click();
}