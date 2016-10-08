#ifndef SIMPLETABLEMODEL_H
#define SIMPLETABLEMODEL_H

#include <QAbstractTableModel>
#include <QFile>
#include <QTextStream>

class SimpleTableModel : public QAbstractTableModel
{
    Q_OBJECT
public:
    explicit SimpleTableModel(QFile *file = 0, QObject *parent = 0);
    int rowCount(const QModelIndex &parent = QModelIndex()) const ;
    int columnCount(const QModelIndex &parent = QModelIndex()) const;
    QVariant data(const QModelIndex &index, int role = Qt::DisplayRole) const;

signals:

public slots:

private:
    void resetToFirstRow() const;

    QFile *_file;
    QTextStream *_fileStream;
    int _rowCount;
    int _columnCount;

    mutable QString _currentLine;
    mutable int _currentRowIndex;
};

#endif // SIMPLETABLEMODEL_H
