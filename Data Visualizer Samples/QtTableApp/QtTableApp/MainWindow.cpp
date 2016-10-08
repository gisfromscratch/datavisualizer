#include "MainWindow.h"
#include "ui_MainWindow.h"

#include "SimpleTableModel.h"

#include <QFileDialog>
#include <QTextStream>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_actionOpen_triggered()
{
    // Open a file
    QString filePath = QFileDialog::getOpenFileName(this, tr("Open file"), "/", tr("CSV Files (*.csv)"));
    QFileInfo fileInfo(filePath);
    if (!fileInfo.exists())
    {
        return;
    }

    // Create a new table model
    SimpleTableModel *tableModel = new SimpleTableModel(new QFile(filePath, this), this);
    ui->tableView->setModel(tableModel);
}
