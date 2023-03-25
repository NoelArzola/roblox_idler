# roblox_idler.py

"""Roblox Idler is an idling tool for Roblox built with Python and PyQT"""

import sys
import keyboard
import time

from PyQt6.QtWidgets import (
    QApplication,
    QMainWindow,
    QWidget,
    QLineEdit,
    QFormLayout,
    QPushButton
)

ERROR_MSG = "ERROR: Enter a valid number"
# WINDOW_SIZE = 235
DELAY = 60 # We will move every minute

keep_alive = True;

class IdlerWindow(QMainWindow):
    """Roblox Idlers main window"""
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Roblox Idler")
        # self.setFixedSize(WINDOW_SIZE, WINDOW_SIZE)
        self.generalLayout = QFormLayout()
        central_widget = QWidget(self)
        central_widget.setLayout(self.generalLayout)
        self.setCentralWidget(central_widget)
        self.input_field = QLineEdit()
        self.input_field.setMaxLength(2)
        self._create_input(self.generalLayout, self.input_field)
        self.start_btn = QPushButton("Start")
        self.stop_btn = QPushButton("Stop")
        self.stop_btn.setDisabled(True)
        self._create_buttons(self.generalLayout, self.start_btn, self.stop_btn)

    def _create_input(self, layout, field):
        layout.addRow("How often should be move your avatar?", field)

    def _create_buttons(self, layout, start, stop):
        layout.addWidget(start) 
        layout.addWidget(stop)

class Idler:
    """Idlers controller class"""
    def __init__(self, model, view):
        self._evaluate = model
        self._view = view
        self._connect_signals_and_slots()

    def _connect_signals_and_slots(self):
     self._view.start_btn.clicked.connect(lambda: run_idler(self._view.input_field.text(), self._view.input_field, self._view.start_btn, self._view.stop_btn))
     self._view.stop_btn.clicked.connect(lambda: end_idler(self._view.input_field, self._view.start_btn, self._view.stop_btn))

def validate_input(input):
    if (not isinstance(input, int)):
        return False
    if (input < 1 or input > 19):
        return False
    return True

def simulate_gameplay():
    # display dialog box and run the code for the right amount of time
    # start_time = 
    time.sleep(10)
    keyboard.send("w")
    time.sleep(1)
    keyboard.send("a")
    time.sleep(1)
    keyboard.send("s")
    time.sleep(1)
    keyboard.send("d")
    time.sleep(1)
    keyboard.send("space")

def run_idler(input, field, btn1, btn2):
    field.setReadOnly(True)
    btn1.setDisabled(True)
    btn2.setDisabled(False)
    if (validate_input(input)):          
        while (keep_alive):
            simulate_gameplay()
            time.sleep(60 * input)

def end_idler(field, start_btn, stop_btn):
    stop_btn.setDisabled(True)
    field.setReadOnly(False)
    global keep_alive
    keep_alive = False
    start_btn.setDisabled(False)

def main():
    """Idlers main function"""
    idler_app = QApplication([])
    idler_window = IdlerWindow()
    idler_window.show()
    Idler(model=run_idler, view=idler_window)
    sys.exit(idler_app.exec())

if __name__ == "__main__":
    main()