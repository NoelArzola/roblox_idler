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
    QPushButton,
    QStatusBar,
)

from PyQt6.QtCore import (
    QObject,
    QThread,
    pyqtSignal
)

ERROR_MSG = "ERROR: Enter a valid number"
# WINDOW_SIZE = 235
DELAY = 60 # We will move every minute

keep_alive = True 

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
        self.status_bar = QStatusBar()
        self.setStatusBar(self.status_bar)
        self.status_bar.showMessage('Click start to begin')
        self.thread = QThread()
        self.worker = Worker()
        self.worker.moveToThread(self.thread)
        self.thread.started.connect(lambda: self.worker.run_idler(self.input_field.text(), self.input_field, self.start_btn, self.stop_btn, self.status_bar))
        self.worker.finished.connect(self.thread.quit)
        self.worker.finished.connect(self.worker.deleteLater)
        self.thread.finished.connect(self.thread.deleteLater)
        self.thread.start()

    def _create_input(self, layout, field):
        layout.addRow("How often should be move your avatar?", field)

    def _create_buttons(self, layout, start, stop):
        layout.addWidget(start) 
        layout.addWidget(stop)

class Idler:
    """Idlers controller class"""
    def __init__(self, model, view):
        self._model = model
        self._view = view
        self._connect_signals_and_slots()

    def _connect_signals_and_slots(self):
     self._view.start_btn.clicked.connect(lambda: self._model.run_idler(self._view.input_field.text(), self._view.input_field, self._view.start_btn, self._view.stop_btn, self._view.status_bar))
     self._view.stop_btn.clicked.connect(lambda: self._model.end_idler(self._view.input_field, self._view.start_btn, self._view.stop_btn, self._view.status_bar))


class Worker(QObject):
    finished = pyqtSignal()

    def grab_input(self, user_value):
        if (user_value in ['', ' ', '  ']):
            user_value = 5
        
        try:
            user_value = int(user_value)
        except ValueError:
            return
        
        return user_value

    def validate_input(self, user_value):
        if (user_value < 1 or user_value > 19):
            return False
        return True

    def simulate_gameplay(self):
        keyboard.send("w")
        time.sleep(1)
        keyboard.send("a")
        time.sleep(1)
        keyboard.send("s")
        time.sleep(1)
        keyboard.send("d")
        time.sleep(1)
        keyboard.send("space")

    def run_idler(self, input, field, btn1, btn2, status):
        field.setReadOnly(True)
        btn1.setDisabled(True)
        btn2.setDisabled(False)
        value = self.grab_input(input)
        if (self.validate_input(value)):
            status.showMessage('Starting in 10 seconds') 
            time.sleep(10) 
            status.showMessage('Running') 
            global keep_alive      
            while (keep_alive):
                self.simulate_gameplay()
                time.sleep(60 * value)
        self.finished.emit()

    def end_idler(self, field, start_btn, stop_btn, status):
        status.showMessage('Ending Idler')
        global keep_alive
        keep_alive = True
        stop_btn.setDisabled(True)
        field.setReadOnly(False)
        start_btn.setDisabled(False)
        status.showMessage('Click start to begin')

def main():
    """Idlers main function"""
    idler_app = QApplication([])
    idler_window = IdlerWindow()
    idler_window.show()
    worker = Worker()
    Idler(model=worker, view=idler_window)
    sys.exit(idler_app.exec())

if __name__ == "__main__":
    main()