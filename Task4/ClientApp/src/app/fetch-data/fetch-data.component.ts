import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public items: BusinessEntity1[];

  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, public dialog: MatDialog) {
    this.http = http;
    this.baseUrl = baseUrl;
  }
  updateItem(newItem) {
    let updateItem = this.items.find(this.findIndexToUpdate, newItem.id);

    let index = this.items.indexOf(updateItem);

    this.items[index] = newItem;
  }

  findIndexToUpdate(newItem) {
    return newItem.id === this;
  }

  openDialog(item: BusinessEntity1): void {
    debugger;
    const dialogRef = this.dialog.open(DialogEditItem, {
      width: '400px',
      height: '400px',
      position: {
        left: '20%'
      },
      data: {
        id: item.id,
        name: item.name,
        description: item.description
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.updateItem(result);
      this.http.post(this.baseUrl + `api/SampleData/save`, result).subscribe(result => {
      }, error => console.error(error));
    });
  }

  findItem(text: string): void {
    this.http.get<BusinessEntity1[]>(this.baseUrl + `api/SampleData/search/${text}`).subscribe(result => {
      this.items = result;
    }, error => console.error(error));
  }


  editItem(item: BusinessEntity1): void {
    debugger;
    this.openDialog(item);
  }
}

@Component({
  selector: 'dialog-edit',
  templateUrl: './edit-dialog.component.html'
  // ,styleUrls: ['edit-dialog.component.css'],
})

export class DialogEditItem {

  constructor(
    public dialogRef: MatDialogRef<DialogEditItem>,
    @Inject(MAT_DIALOG_DATA) public data: BusinessEntity1) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

interface BusinessEntity1 {
  id: number;
  name: string;
  description: string;
}
