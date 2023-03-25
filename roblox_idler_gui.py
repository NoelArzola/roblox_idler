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
        self._create_input(self.generalLayout)
        self._create_buttons(self.generalLayout)

    def _create_input(self, layout):
        input_field = QLineEdit()
        input_field.setMaxLength(2)
        layout.addRow("How often should be move your avatar?", input_field)

    def _create_buttons(self, layout):
        start_btn = QPushButton("Start")
        stop_btn = QPushButton("Stop")
        layout.addWidget(start_btn) 
        layout.addWidget(stop_btn)

def main():
    """Idlers main function"""
    idler_app = QApplication([])
    idler_window = IdlerWindow()
    idler_window.show()
    sys.exit(idler_app.exec())

if __name__ == "__main__":
    main()

class Idler:
    """Idlers controller class"""
    def __init__(self, model, view):
        self._evaluate = model
        self._view = view
        self._connect_signals_and_slots()

    def _validate_input(self, input = 5):
        if (not isinstance(input, int)):
            return False
        if (input < 1 or input > 19):
            return False
        return True
    
    def _simulate_gameplay(self):
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

    def _run_idler(self, input):
        if (self._validate_input(input)):          
            while (keep_alive):
                self._simulate_gameplay()
                time.sleep(60 * input)

    # def _connect_signals_and_slots(self):
    #  self._view.