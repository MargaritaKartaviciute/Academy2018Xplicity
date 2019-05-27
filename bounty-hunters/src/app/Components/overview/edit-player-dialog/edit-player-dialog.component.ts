import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PlayerService } from '../../../services/player.service';
import { Player } from '../../../Models/Player';

@Component({
  templateUrl: './edit-player-dialog.component.html',
  styleUrls: ['./edit-player-dialog.component.scss']
})

export class EditPlayerDialogComponent implements OnInit {

  form: FormGroup;
  playerUsername: string;

  constructor(
    private playerService: PlayerService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<EditPlayerDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data
  ) {}

  updatePlayer(player: Player) {
    if (`${this.form.value.username}` != null && `${this.form.value.username}` !== '') {
      player.username = `${this.form.value.username}`;
    }
    this.playerService.updatePlayer(player).subscribe(data => {
      // this.data = data;
    });
  }

  ngOnInit() {
    (<HTMLInputElement>document.getElementById('username-form')).value = this.data.username;
    this.playerUsername = '';
    this.form = this.formBuilder.group({
      username: this.data.username ? this.data.username : ''
    });
    console.log('player username is: ' + this.data.username);
  }

  submit(form) {
    this.dialogRef.close(`${form.value.username}`);
  }

// Black magic in action:
  closeDialog() {
  // this.dialogRef.close();
  }
  }
